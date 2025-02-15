﻿using System.IO;

namespace MongoBackupAssistant
{
    internal static partial class Mongo
    {
        public static void Copy(CopyOptions options)
        {
            var dumpOptions = new DumpOptions
            {
                Host = options.FromHost,
                Port = options.FromPort,
                DatabaseName = options.FromDatabase,
                Query = options.Query,
                OutputPath = options.Path,
                MongoDumpBinary = options.MongoDumpBinary
            };
            Dump(dumpOptions);

            var restoreOptions = new RestoreOptions
            {
                Host = options.ToHost,
                Port = options.ToPort,
                DatabaseName = options.ToDatabase,
                Drop = options.Drop,
                InputPath = Path.Combine(options.Path, options.FromDatabase),
                MongoRestoreBinary = options.MongoRestoreBinary
            };
            Restore(restoreOptions);
        }
    }
}
