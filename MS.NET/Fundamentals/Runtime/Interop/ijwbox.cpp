#include "legacy/include/box.h"

namespace Ijw
{
	public ref class LegacyBox
	{
	public:
		LegacyBox(int l, int b, int h)
		{
			length = l;
			breadth = b;
			height = h;
		}

		int GetInnerVolume(int thickness)
		{
			return BoxVolume(length, breadth, height, thickness);
		}
	private:
		int length, breadth, height;
	};
}

