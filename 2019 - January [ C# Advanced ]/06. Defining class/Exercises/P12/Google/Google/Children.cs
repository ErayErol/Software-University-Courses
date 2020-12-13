namespace Google
{
    public class Children
    {
        private string childName;
        private string childBirthday;

        public Children()
        {

        }
        public Children(string childName, string childBirthday)
        {
            this.ChildName = childName;
            this.ChildBirthday = childBirthday;
        }
        public override string ToString()
        {
            if (childName == null)
            {
                return null;
            }
            return "\r\n" + this.ChildName + " " + this.ChildBirthday;
        }

        public string ChildName { get => childName; set => childName = value; }
        public string ChildBirthday { get => childBirthday; set => childBirthday = value; }
    }
}