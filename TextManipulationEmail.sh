#!/bin/bash
#Removes commas and periods that might trail email addresses
sed 's/[.,]//g' | \

#Counts each unique email address.
awk '{count[$0]++} END {for (email in count) print count[email], "-", email}' | \

#Converts all emails to lowercase.
tr '[:upper:]' '[:lower:]' | \
#Extracts only the email addresses from each line.
grep -Eo '[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}' | \
