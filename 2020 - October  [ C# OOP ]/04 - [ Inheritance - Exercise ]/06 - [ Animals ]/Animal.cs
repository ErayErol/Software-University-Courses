namespace Animals
{
    using System.Text;

    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; }

        public int Age { get; }

        public string Gender { get; }

        public abstract string ProduceSound();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());

            return sb.ToString().Trim();
        }
    }
}
