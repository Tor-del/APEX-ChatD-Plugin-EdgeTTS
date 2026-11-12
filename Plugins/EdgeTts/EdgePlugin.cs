using System.IO;
using ApexChatd.Plugins;
using ScreenReader.Edge;

namespace ApexChatd.EdgeTts;

public sealed class EdgePlugin : Plugin
{
    public override void Register(IPluginContext context) => context.RegisterSpeechProvider("edge", new EdgeProvider());

    private sealed class EdgeProvider : SpeechProvider
    {
        private readonly EdgeSpeechClient client = new();
        private IReadOnlyList<Voice>? catalog;
        public override string Name => "Edge TTS";
        public override IReadOnlyList<Voice> DefaultVoices => EdgeVoiceCatalog.Defaults;

        public override async Task<IReadOnlyList<Voice>> GetVoicesAsync(CancellationToken cancellationToken) =>
            catalog ??= (await client.GetVoicesAsync(cancellationToken))
                .Select(voice => new Voice(voice.ShortName, voice.FriendlyName, voice.Locale)).ToArray();

        public override async Task<AudioFormat> SynthesizeAsync(SpeechRequest request, Stream destination,
            CancellationToken cancellationToken)
        {
            await foreach (var chunk in client.StreamAsync(new(request.Text, request.VoiceId, request.Language, request.Rate),
                cancellationToken))
                await destination.WriteAsync(chunk, cancellationToken);
            return AudioFormat.Mp3;
        }
    }
}
