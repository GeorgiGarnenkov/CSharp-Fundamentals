namespace EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }


        public Handler Handler { get; set; }


        public void OnNameChange(NameChangeEventArgs args)
        {
            if (args != null)
            {
                this.NameChange(this, args);
            }
        }
    }
}