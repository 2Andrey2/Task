using System.Collections.Generic;
using Task_Server_.Services.Operations;
using Task_Server_.Services.Operations.Authorization;


namespace Task_Server_.Services
{
    static class AnalysisTask
    {
        public static List<string> Analysis(List<string> task)
        {
            Authorization authorization = new ();
            string[] tasks = task[0].Split(' ');
            if (authorization.CheckingRights(tasks, task))
            {
                IOperations operations = Fabric(task[0]);
                return new List<string> { operations.gettype(tasks[1]) };
            }
            return new List<string> { "Недостаточно прав" };
        }

        public static object CompletingTask(string task, object massinfo)
        {
            string[] tasks = task.Split(' ');
            IOperations operations = Fabric(task);
            if (tasks.Length > 3)
            {
                List<string> paramss = new ();
                for (int i = 3; i < tasks.Length; i++)
                {
                    paramss.Add(tasks[i]);
                }
                return operations.running(tasks[1], massinfo, paramss);
            } else {
                return operations.running(tasks[1], massinfo, null);
            }
        }

        private static IOperations Fabric (string task)
        {
            string[] tasks = task.Split(' ');
            IOperations operations = null;
            if (tasks[0] == "user")
            {
                if (tasks[2] == "internal")
                {
                    operations = new Operations.InternalOperations.TaskUser();
                }
                if (tasks[2] == "external")
                {
                    operations = new Operations.ExternalOperations.TaskUser();
                }
            }
            if (tasks[0] == "messages")
            {
                if (tasks[2] == "internal")
                {
                    operations = new Operations.InternalOperations.TaskMessages();
                }
                if (tasks[2] == "external")
                {
                    operations = new Operations.ExternalOperations.TaskMessages();
                }
            }
            if (tasks[0] == "group")
            {
                if (tasks[2] == "internal")
                {
                    operations = new Operations.InternalOperations.TaskGroups();
                }
                if (tasks[2] == "external")
                {
                    operations = new Operations.ExternalOperations.TaskGroups();
                }
            }
            if (tasks[0] == "chat")
            {
                if (tasks[2] == "internal")
                {
                    operations = new Operations.InternalOperations.TaskChat();
                }
                if (tasks[2] == "external")
                {
                    operations = new Operations.ExternalOperations.TaskChat();
                }
            }
            if (tasks[0] == "authorization")
            {
                operations = new Authorization();
            }
            return operations;
        }
    }
}
