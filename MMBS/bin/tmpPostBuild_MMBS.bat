WinRAR a MMBS.rar MMBS -IBCK
@echo off

powershell -Command "& {Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.MessageBox]::Show('Archiving Completed', 'COMPRESSED', 'OK', [System.Windows.Forms.MessageBoxIcon]::Information);}"