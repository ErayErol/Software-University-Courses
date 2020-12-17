namespace Logger.Models.Factories
{
    using Contracts;
    using Layouts;

    using System;

    public class LayoutFactory
    {
        public ILayout ProduceLayout(string layoutType)
        {
            ILayout layout;

            if (layoutType == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else
            {
                throw new ArgumentException("Invalid layout type!");
            }

            return layout;
        }
    }
}
