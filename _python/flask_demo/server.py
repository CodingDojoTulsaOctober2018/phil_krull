from flask import Flask

app = Flask(__name__)
print(__name__)

@app.route('/')
def index():
    return 'from index method in server.py'

@app.route('/success')
def success():
    # do any python logic
    
    return 'from success method in server.py'

if __name__ == '__main__':
    app.run(debug=True)