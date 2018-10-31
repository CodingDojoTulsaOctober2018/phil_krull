# ++++++++++++++++++++++++++++++++++++++ 01 ++++++++++++++++++++++++++++++++++++++
x = [ [5,2,3], [10,8,9] ]
students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]

# How would you change the value 10 in x to 15?  Once you're done x should then be [ [5,2,3], [15,8,9] ].  
'''print(x)
print(type(x))
print(x[0])
print(x[1][0])
x[1][0] = 15
print(x)'''

# How would you change the last_name of the first student from 'Jordan' to "Bryant"?
'''print(students)
print(type(students))
print(students[0])
print(students[1])
print(type(students[0]))
print(students[0].keys())
print(students[0]['last_name'])
students[0]['last_name'] = 'Bryant'
print(students[0])'''

# For the sports_directory, how would you change 'Messi' to 'Andres'?
# print(sports_directory['soccer'])
# sports_directory['soccer'][0] = 'Andres'
# print(sports_directory['soccer'])

# For z, how would you change the value 20 to 30?
'''print(len(z))
print(z[0])
z[0]['y'] = 30
print(z)'''

# ++++++++++++++++++++++++++++++++++++++ 02 ++++++++++++++++++++++++++++++++++++++
# Create a function that given a list of dictionaries, it loops through each dictionary in the list and prints each key and the associated value.  For example, given the following list:
# first_name - Michael, last_name - Jordan
# first_name - John, last_name - Rosales
# first_name - Mark, last_name - Guillen
# first_name - KB, last_name - Tonel

students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales', 'location': 'Tulsa'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
]

def iterateList(arr):
    # print(arr)
    for student in students:
        # print(student)
        keys = student.keys()
        str_builder = ''
        for key in keys:
            str_builder += key + ' - ' + student[key] + ', '
        # print(str_builder.rstrip(', '))
        str_builder = str_builder.rstrip(', ')
        print(str_builder)

    print('-'*90)

iterateList(students)

# ++++++++++++++++++++++++++++++++++++++ 03 ++++++++++++++++++++++++++++++++++++++
# Create a function that given a list of dictionaries and a key name, it outputs the value stored in that key for each dictionary.  For example, iterateDictionary2('first_name', students) should output
# Michael
# John
# Mark
# KB
def iterateDictionary2(key, arr):
    for value in arr:
        print(value)
        if key in value:
            print(value[key])
        else:
            print('key not arr')

# iterateDictionary2('first_name', students)
# print('*'*90)
# iterateDictionary2('last_name', students)
# iterateDictionary2('location', students)


# ++++++++++++++++++++++++++++++++++++++ 04 ++++++++++++++++++++++++++++++++++++++
# Create a function that prints the name of each location and also how many locations the Dojo currently has.  Have the function also print the name of each instructor and how many instructors the Dojo currently has.  For example, printDojoInfo(dojo) should output
# 7 LOCATIONS
# San Jose
# Seattle
# Dallas
# Chicago
# Tulsa
# DC
# Burbank

# 8 INSTRUCTORS
# Michael
# Amy
# Eduardo
# Josh
# Graham
# Patrick
# Minh
# Devon

dojo = {
   'locations': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
   'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Phil', 'Devon']
}

def printDojoInfo(dictonary):
    for dic in dictonary:
        print(len(dictonary[dic]), dic.upper())
        for name in dictonary[dic]:
            print(name)

printDojoInfo(dojo)
