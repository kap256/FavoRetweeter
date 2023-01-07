attrib -R "Script\fr_common.js"
xcopy "..\firefox\fr_common.js" "Script\fr_common.js" /Y /F
attrib +R "Script\fr_common.js"
exit 0