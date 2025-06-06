using System;
using System.Collections.Generic;
using System.Text;

namespace zav3
{
    interface IRenderer
    {
        void Render(string shapeName);
    }
    class VectorRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} as vector lines.");
        }
    }
    class RasterRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} as pixels.");
        }
    }
    abstract class Shape
    {
        protected IRenderer renderer;

        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
    }
    class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            renderer.Render("Circle");
        }
    }
    class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            renderer.Render("Square");
        }
    }
    class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            renderer.Render("Triangle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            Shape circle = new Circle(vectorRenderer);
            Shape square = new Square(rasterRenderer);
            Shape triangle = new Triangle(vectorRenderer);

            circle.Draw();
            square.Draw();
            triangle.Draw();
        }
    }
}

