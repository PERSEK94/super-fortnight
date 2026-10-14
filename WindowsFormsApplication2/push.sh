#!/bin/bash
echo "escriba que archivo quiere actualizar (si quiere actualizar todos, presione enter)"
read archive

if [ -z "$archive" ]; then
git add .
elif [ -f "$archive" ]; then
git add "$archive"
else
echo "archivo equivocado o inexistente. intente otra vez o crease ese archivo"
exit 1
fi

echo "Que actualizo?"
read rsnrepo
git commit -m "$rsnrepo"
git push
