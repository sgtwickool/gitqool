using System.CommandLine;

Option<string> serverOption = new(
    aliases: new[] { "--servername", "-s" },
    description: "server name on which your target database is stored",
    getDefaultValue: () => "gk-db01"
)
{ IsRequired = true };

Option<string> databaseOption = new(
    aliases: new[] { "--database", "-d" },
    description: "database name",
    getDefaultValue: () => "IVIEWALPHA"
);

Option<string> usernameOption = new(
    aliases: new[] { "--username", "-u" },
    description: "sql server log in username"
);

Option<string> passwordOption = new(
    aliases: new[] { "--password", "-p" },
    description: "sql server log in password"
);

Option<string> locationOption = new(
    aliases: new[] { "--location", "-l" },
    description: "location of folder containing local repository where you want to store files",
    getDefaultValue: () => Directory.GetCurrentDirectory()
);

Command saveCommand = new(name: "save", "save database schema to git repo") {
    serverOption,
    databaseOption,
    usernameOption,
    passwordOption,
    locationOption,
};

RootCommand rootCommand = new(description: "git integration for SQL Server") {
    saveCommand,
};

rootCommand.SetHandler((saveCommand) =>
    {
        Console.WriteLine("You must define a command!");
    });

saveCommand.SetHandler((serverOptionValue, databaseOptionValue, usernameOptionValue, passwordOptionValue, locationOptionValue) =>
    {
        Console.WriteLine($"--servername = {serverOptionValue}");
        Console.WriteLine($"--database = {databaseOptionValue}");
        Console.WriteLine($"--username = {usernameOptionValue}");
        Console.WriteLine($"--password = {passwordOptionValue}");
        Console.WriteLine($"--location = {locationOptionValue}");
    },
    serverOption, databaseOption, usernameOption, passwordOption, locationOption);

await rootCommand.InvokeAsync(args);