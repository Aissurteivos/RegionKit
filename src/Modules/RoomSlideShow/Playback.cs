using System.Text.RegularExpressions;

namespace RegionKit.Modules.Slideshow;

internal class Playback
{
	public readonly List<PlaybackStep> playbackSteps;
	public readonly bool loop;
	public readonly string id;

	public Playback(
		List<PlaybackStep> playbackSteps,
		bool loop,
		string id)
	{
		this.playbackSteps = playbackSteps;
		this.loop = loop;
		this.id = id;
	}


	private Playback PushNewFrame(
		Frame.Raw raw)
	{
		int newIndex = this.playbackSteps.Count;
		// KeyFrame[] keyFrames = keyFramesRaw.Select(kfr => new KeyFrame(newIndex, kfr)).ToArray();

		playbackSteps.Add(new Frame(newIndex, raw));
		return this;
	}
	private Playback PushNewStep(PlaybackStep newStep)
	{
		playbackSteps.Add(newStep);
		return this;
	}
	public static Playback MakeTestPlayback()
	{
		Playback result = _Read.FromText("test", _Read.EXAMPLE_SYNTAX.Split('\n'));
		// Playback result = new Playback(
		// 	playbackSteps: new List<PlaybackStep>() {

		// 		new SetDelay(40),
		// 		new SetShader("PLOO"),
		// 		new SetInterpolation(InterpolationKind.Linear, new[] {Channel.R, Channel.B})
		// 	},
		// 	true,
		// 	"test");
		// result.PushNewFrame(new ("LizardHead0.1", 60, new KeyFrame.Raw[] { new(Channel.R, 0f), new(Channel.B, 0f) }));
		// //result.PushNewFrame("circle20", null, new KeyFrame.Raw[0]);
		// result.PushNewFrame(new("Circle20", null, new KeyFrame.Raw[0]));
		// result.PushNewFrame(new("LizardHead0.2", 60, new KeyFrame.Raw[] { new(Channel.R, 1f) }));
		// // result.PushNewFrame("circle20", null, new KeyFrame.Raw[0]);
		// // result.PushNewFrame("circle20", null, new KeyFrame.Raw[0]);
		// result.PushNewFrame(new("Circle20", null, new KeyFrame.Raw[0]));
		// result.PushNewFrame(new("LizardHead0.3", 60, new KeyFrame.Raw[] { new(Channel.B, 1f) }));
		return result;
	}
}