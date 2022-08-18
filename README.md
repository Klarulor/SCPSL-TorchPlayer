# TorchPlayer plugin for SCP:SL (EXILED)

## Commands
| Command                    | Description                                  |
|----------------------------|----------------------------------------------|
| clearlights                | Burn all player lights                       |
| setlight <ID> <IS_RAINBOW> | Create light for player                      |
| .light                     | Create light from client console for players |

## Config
```
torch_player:
# Enable
  is_enabled: true
  # Light intensity
  light_intensity: 1
  # Light range
  light_range: 6
  # Light shadows
  light_shadow: true
  # Default light color
  light_color:
    r: 50
    g: 50
    b: 50
    w: 1
  # Rainbow frames
  rainbow_frames:
  - color:
      r: 255
      g: 0
      b: 0
      w: 1
    delay: 1
  - color:
      r: 0
      g: 255
      b: 0
      w: 1
    delay: 1
  # Badge names with raionbow allowed
  rainbow_role_allowd:
  - owner
  - admin
```