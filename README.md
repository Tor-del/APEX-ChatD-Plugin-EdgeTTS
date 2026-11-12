# APEX ChatD Edge TTS plugin

Edge TTS adds a voice provider to [APEX ChatD](https://github.com/Tor-del/APEX-ChatD). Download `APEX-ChatD-Plugin-EdgeTTS.zip` from the [latest release](https://github.com/Tor-del/APEX-ChatD-Plugin-EdgeTTS/releases/latest) and install it from **Plugins → Add plugin**. Enable it and restart APEX ChatD.

The provider ID is `apexchatd.edge-tts/edge`. Existing Edge TTS voice profiles use this same ID. See the [third-party notices](Plugins/EdgeTts/THIRD-PARTY-NOTICES.md) for the licensing and source of the separate Edge speech library. Edge Read Aloud is a Microsoft service.

Build with .NET 10 and PowerShell 7 on Windows:

```powershell
.\Plugins\build-package.ps1 -Project Plugins/EdgeTts/EdgeTts.csproj -OutputDirectory bin/package -Zip bin/APEX-ChatD-Plugin-EdgeTTS.zip
```

The `PluginSdk` directory is a snapshot of the APEX ChatD SDK 1.2.0. It keeps this repository buildable independently. The application supplies the SDK DLL at runtime. The plugin supports the SDK API from 1.0.0 up to 2.0.0 as specified in its manifest.

For a release, update the manifest version and push a matching tag such as `v1.0.0`. GitHub Actions builds the ZIP, signs its manifest with the `APEXCHATD_PLUGIN_SIGNING_KEY` repository secret, and verifies the signature with the public key trusted by APEX ChatD before publishing. The main application release uses this ZIP as the Edge TTS installer payload.
