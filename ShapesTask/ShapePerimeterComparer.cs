namespace ShapesTask;

class ShapePerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 is null)
        {
            throw new ArgumentNullException(nameof(shape1), "Аргумент shape1 не должен быть равен null");
        }

        if (shape2 is null)
        {
            throw new ArgumentNullException(nameof(shape2), "Аргумент shape2 не должен быть равен null");
        }

        return shape2.GetPerimeter().CompareTo(shape1.GetPerimeter());
    }
}