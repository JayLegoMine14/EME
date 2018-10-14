from bs4 import BeautifulSoup
import urllib
from urllib.parse import urljoin
import argparse
# import sys

# print("success change")
# for x in range(0,10):
#     print(x)
# f = open("test.txt", "w")
#f.write(sys.argv)
# print("Begin args")
# print(sys.argv)

parser = argparse.ArgumentParser(description='Scrape text and images off of websites')
parser.add_argument("-name", required=False, help="the names to search for", nargs='+')
parser.add_argument("-urls", required=False, help="the pages to search", nargs='+')

args = parser.parse_args()

name = ''
for n in args.name:
    name += n + ' '
urls = args.urls

for url in urls:
    with urllib.request.urlopen(url) as fp:
        soup = BeautifulSoup(fp, 'lxml')
        
        print(name.strip() + ',')
        print(url + ',')
        print(soup.title.string.strip() + ',')

        for image in soup.find_all('img'):
            print(urljoin(url, image['src']))
        print(',')
        for p in soup.find_all('p'):
            if (p.get_text()):
                print(p.get_text())
print('|')
