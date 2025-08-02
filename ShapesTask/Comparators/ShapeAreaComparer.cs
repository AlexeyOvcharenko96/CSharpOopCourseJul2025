using ShapesTask.Shapes;

namespace ShapesTask.Comparators;

class ShapeAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 is null)
        {
            throw new ArgumentNullException(nameof(shape1));
        }

        if (shape2 is null)
        {
            throw new ArgumentNullException(nameof(shape2));
        }

        return shape1.GetArea().CompareTo(shape2.GetArea());
    }
}