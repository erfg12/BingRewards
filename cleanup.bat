for /d /r . %%d in (obj,debug) do @if exist "%%d" rd /s/q "%%d"
del /S /F /AH *.suo
rmdir /s /q ".vs"
rmdir /s /q "bingRewards\obj"
rmdir /s /q "bingRewards Setup\Release"
rmdir /s /q "bingRewards Setup\Debug"
rmdir /s /q "bingRewards\bin"
rmdir /s /q "packages"