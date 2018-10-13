from bs4 import BeautifulSoup
import urllib
import argparse

parser = argparse.ArgumentParser(description='Scrape text and images off of websites')
parser.add_argument("-names", required=True, help="the names to search for")
parser.add_argument("-urls", required=True, help="the pages to search")

args = parser.parse_args()

names = args.names
urls = args.urls

for url in urls.split(','):
    with urllib.request.urlopen(url) as fp:
        soup = BeautifulSoup(fp, 'lxml')
        title = soup.find_all('title')

        with open('test.txt', 'w') as f:
            f.write(soup.prettify())

        print('Title')
        print(soup.title.string)

        print('Paragraphs')
        print(soup.p.text)
        # for p in soup.find_all('p'):
        #     if p:
        #     # for name in names:
        #     #     if p.find(name):
        #         print(p.string)

        # print('S')
        # for s in soup.find_all('section'):
        #     print(s.string)

        # print('A')
        # for a in soup.find_all('article'):
        #     print(a.string)

        # print('Links')
        # for link in soup.find_all('a'):
        #     print(link.string)

        # print('Images')
        # for image in soup.find_all('img'):
        #     print(image['src'])
