#!/Users/rdunn/virtualenvs/py3/bin python3

from requests import session
from datetime import datetime

data_file_path = '/tmp/py-webrequests-data.txt'
output_file_path = '/tmp/py-webrequests-output.log'
deliminator = ','
base_url = 'https://somewebsite.com'
login_path = '/login'

payload = {
    'username': 'myusername',
    'password': 'mypassword'
}

print(str(datetime.now()) + ' START')

with session() as reqs:
    #Login to the website
    reqs.post(base_url + login_path, data=payload)

    #Build the request urls using data from a text file
    with open(data_file_path, 'rt') as data_file:
        for line in data_file:
            parameter_1 = line.rstrip('\n').split(deliminator)[0].strip()
            parameter_2 = line.rstrip('\n').split(deliminator)[1].strip()
            url = base_url + '?p1=%s&p2=%s' %(paramter_1, parameter_2)
            #Send the request and log the result
            request = reqs.get(url)
            output = str(datetime.now()) + ' ' + url + ' ' + request.text
            print(output)
            with open(output_file_path, "a") as output_file:
                output_file.write(output+'\n')

print(str(datetime.now()) + ' END')
