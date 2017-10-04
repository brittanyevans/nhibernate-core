﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Data;
using System.Data.Common;

namespace NHibernate.Driver
{
	using System.Threading.Tasks;
	using System.Threading;
	public partial class SQLite20Driver : ReflectionBasedDriver
	{

        private static async Task Connection_StateChangeAsync(object sender, StateChangeEventArgs e, CancellationToken cancellationToken)
        {
               cancellationToken.ThrowIfCancellationRequested();
            if ((e.OriginalState == ConnectionState.Broken || e.OriginalState == ConnectionState.Closed || e.OriginalState == ConnectionState.Connecting) &&
                e.CurrentState == ConnectionState.Open)
            {
                var connection = (DbConnection)sender;
                using (var command = connection.CreateCommand())
                {
                    // Activated foreign keys if supported by SQLite.  Unknown pragmas are ignored.
                    command.CommandText = "PRAGMA foreign_keys = ON";
                    await (command.ExecuteNonQueryAsync(cancellationToken)).ConfigureAwait(false);
                }
            }
        }
	}
}