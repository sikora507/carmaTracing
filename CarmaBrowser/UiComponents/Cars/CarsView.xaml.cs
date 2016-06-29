using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace CarmaBrowser.UiComponents
{
    /// <summary>
    /// Interaction logic for CarsView.xaml
    /// </summary>
    public partial class CarsView : UserControl
    {
        public CarsView()
        {
            InitializeComponent();
            //// front face
            //_mesh.Positions.Add(new Point3D(-10, 0, 0));
            //_mesh.Positions.Add(new Point3D(10, 0, 0));
            //_mesh.Positions.Add(new Point3D(-10, 20, 0));
            //_mesh.Positions.Add(new Point3D(10, 20, 0));
            //// up face
            //_mesh.Positions.Add(new Point3D(-10, 20, -20));
            //_mesh.Positions.Add(new Point3D(-10, 20, 0));
            //_mesh.Positions.Add(new Point3D(10, 20, 0));
            //_mesh.Positions.Add(new Point3D(10, 20, -20));

            //// front face (counter clockwise)
            //_mesh.TriangleIndices.Add(0);
            //_mesh.TriangleIndices.Add(1);
            //_mesh.TriangleIndices.Add(2);
            //_mesh.TriangleIndices.Add(3);
            //_mesh.TriangleIndices.Add(2);
            //_mesh.TriangleIndices.Add(1);
            //// up face
            //_mesh.TriangleIndices.Add(4);
            //_mesh.TriangleIndices.Add(5);
            //_mesh.TriangleIndices.Add(6);
            //_mesh.TriangleIndices.Add(7);
            //_mesh.TriangleIndices.Add(6);
            //_mesh.TriangleIndices.Add(5);
        }
    }
}
