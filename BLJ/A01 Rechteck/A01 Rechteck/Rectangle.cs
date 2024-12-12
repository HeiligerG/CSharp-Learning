namespace A01_Rechteck
{
    internal class Rectangle
    {
        private double height;
        private double width;

        public double Height 
        { 
            get => height;
            set => height = value;
        }

        public double Width
        {
            get => width;
            set => width = value;
        }

        internal Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        internal double BerechneFlaeche()
        {
            return height * width;
        }
    }
}