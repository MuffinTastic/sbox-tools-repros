using Tools;

namespace Repro;

public class ReproConnection : GraphicsLine
{
	Vector2 StartPosition;

	public ReproConnection( Vector2 start )
	{
		StartPosition = start;
	}

	protected override void OnPaint()
	{
		var color = Color.Red;
		var width = 4.0f;

		Paint.SetPen( color, width );

		PaintLine();
	}

	internal void Layout( Vector2 scenePosition )
	{
		var rect = new Rect( StartPosition );
		rect = rect.AddPoint( scenePosition );

		rect.Position -= 100.0f;
		rect.Size += 200.0f;

		Position = rect.Position;
		Size = rect.Size;

		Clear();

		var startPos = FromScene( StartPosition );
		var endPos = FromScene( scenePosition );

		MoveTo( startPos );
		CubicLineTo( startPos + new Vector2( 100, 0 ), (startPos + endPos) * 0.5f, endPos );

		Update();
	}
}
