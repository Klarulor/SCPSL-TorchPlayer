using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdminToys;
using Exiled.API.Features;
using MEC;
using Mirror;
using UnityEngine;
using UnityEngine.Playables;
using Object = System.Object;

namespace TorchPlayer
{
    internal class EventHandler
    {
        internal static readonly Dictionary<Player, LightSourceToy> Lights = new Dictionary<Player, LightSourceToy>();
        private static readonly Dictionary<Player, CoroutineHandle> CoroutineHandlers = new Dictionary<Player, CoroutineHandle>();
        internal void OnWaitingForPlayers()
        {
        }

        internal static void SpawnLight(Player owner, bool rainbow = false)
        {
            var toy = CreateLightSource(Vector3.zero, Vector3.one, Vector3.zero);
            toy.NetworkLightIntensity = Plugin.Instance.Config.LightIntensity;
            toy.NetworkLightRange = Plugin.Instance.Config.LightRange;
            toy.NetworkLightShadows = Plugin.Instance.Config.LightShadow;
            toy.gameObject.transform.parent = owner.GameObject.transform;
            toy.gameObject.transform.localPosition = Vector3.zero;
            Lights.Add(owner, toy);
            if (!rainbow)
                toy.NetworkLightColor = Plugin.Instance.Config.LightColor.Normalize();
            else
            {
                CoroutineHandlers.Add(owner, MEC.Timing.RunCoroutine(RainbowColorCoroutine(owner)));
            }
            NetworkServer.Spawn(toy.gameObject);
        }

        internal static void BurnLight(Player owner)
        {
            if (CoroutineHandlers.ContainsKey(owner))
            {
                MEC.Timing.KillCoroutines(CoroutineHandlers[owner].GetHashCode());
                CoroutineHandlers.Remove(owner);
            }
            NetworkServer.UnSpawn(Lights[owner].gameObject);
            Lights.Remove(owner);
        }

        internal static void BurnAllLights()
        {
            var lights = Lights.ToList();
            foreach(var light in lights)
                BurnLight(light.Key);
        }
        private static LightSourceToy CreateLightSource(Vector3 position, Vector3 scale, Vector3 eular)
        {
            bool success = NetworkClient.GetPrefab(Guid.Parse("6996edbf-2adf-a5b4-e8ce-e089cf9710ae"), out var gm);
            if (!success) throw new Exception("Light source prefab cannot find in NetworkClient::GetPrefab()");
            LightSourceToy adminToyBase = UnityEngine.Object.Instantiate<AdminToys.LightSourceToy>(gm.GetComponent<LightSourceToy>());
            return adminToyBase;
        }

        private static IEnumerator<float> RainbowColorCoroutine(Player owner)
        {
            int i = 0;
            for (;;)
            {
                if (i >= Plugin.Instance.Config.RainbowFrames.Length)
                    i = 0;
                Lights[owner].NetworkLightColor = Plugin.Instance.Config.RainbowFrames[i].Color.Normalize();
                yield return Timing.WaitForSeconds(Plugin.Instance.Config.RainbowFrames[i].Delay);
                i++;
            }
        }
    }
}