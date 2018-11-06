from flask import Flask, render_template, request, redirect, session
from random import randint
from datetime import datetime

app = Flask(__name__)
app.secret_key = 'my super secret key'

@app.route('/')
def index():
    if 'total_gold' not in session:
        session['total_gold'] = 0
        session['activities'] = []

    return render_template('index.html', key='value')

@app.route('/test/<color>')
def what_color(color):
    print('color is:', color)
    return redirect('/')

@app.route('/process_money/<building>', methods=['post'])
def process(building):
    print('route params', building)
    # if farm
    if request.form['building'] == 'farm':
        # create a random number
        num = randint(10, 21)
        session['total_gold'] += num
        print(session['total_gold'])
        print('random number farm', num)

    #if cave
    if request.form['building'] == 'cave':
        # create a random number
        num = randint(5, 11)
        session['total_gold'] += num
        print(session['total_gold'])
        print('random number cave', num)

    #if house
    if request.form['building'] == 'house':
        # create a random number
        num = randint(2, 6)
        session['total_gold'] += num
        print(session['total_gold'])
        print('random number house', num)

    #if casino
    if request.form['building'] == 'casino':
        # create a random number
        num = randint(-50, 51)
        session['total_gold'] += num
        print(session['total_gold'])
        print('random number casino', num)

    # result = { 'message': string, 'class': gain/lost}
    if num < 0:
        session['activities'].append({'message': 'You entered a casino and lost {} golds!......ouch......({})'.format(abs(num), datetime.now().strftime("%A, %d. %B %Y %I:%M%p")), 'class': 'lost'})
    else:
        session['activities'].append({'message': 'Earned {} golds from the {}!........({})'.format(num, request.form['building'], datetime.now().strftime("%A %d, %B %Y %I:%M%p")), 'class': 'gained'})

    return redirect('/')

@app.route('/reset', methods=['post'])
def reset():
    session.clear()
    return redirect('/')

app.run(debug = True)