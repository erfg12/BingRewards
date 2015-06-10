for /d /r . %%d in (obj,debug) do @if exist "%%d" rd /s/q "%%d"
del /S /F /AH *.suo
rmdir /s /q "bingRewards\obj"
rmdir /s /q "bingRewards Setup\Release"
rmdir /s /q "bingRewards\bin\Debug"
cd "bingRewards\bin\Release"
del /S /F *.exe
del /S /F *.vshost.*
del /S /F *.pdb
del /S /F *.config
del /S /F *.manifest