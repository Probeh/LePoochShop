robocopy /mir /s /e . %onedrive%\\snapshots\\LePoochServer-Client\\snapshot-%date:~0,2%-%date:~3,2%-%date:~-4%_%random% /xd "node_modules" /xd ".git" /xd "dist" /xd "docs" /xd "e2e" & exit