namespace CustomListIterator
{
    using System;

    public class CommandInterpreter
    {
        public void Run()
        {
            MyList<string> data = new MyList<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var commandArgs = input.Split(' ');

                ExecuteCommand(data, commandArgs);
            }
        }

        private void ExecuteCommand(MyList<string> data, string[] commandArgs)
        {
            var command = commandArgs[0];

            switch (command)
            {
                case "Add":
                    var addElement = commandArgs[1];

                    data.Add(addElement);
                    break;

                case "Remove":
                    var index = int.Parse(commandArgs[1]);

                    data.Remove(index);
                    break;

                case "Contains":
                    var containsElement = commandArgs[1];

                    Console.WriteLine(data.Contains(containsElement));
                    break;

                case "Swap":
                    var index1 = int.Parse(commandArgs[1]);
                    var index2 = int.Parse(commandArgs[2]);

                    data.Swap(index1, index2);
                    break;

                case "Greater":
                    var element = commandArgs[1];

                    Console.WriteLine(data.CountGreaterThan(element));
                    break;

                case "Max":

                    Console.WriteLine(data.Max());
                    break;

                case "Min":

                    Console.WriteLine(data.Min());
                    break;

                case "Sort":
                    data.SortData();
                    break;

                case "Print":
                    Console.WriteLine(data.ToString());
                    break;
            }
        }
    }
}
