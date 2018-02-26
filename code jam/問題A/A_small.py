#! python3
# coding: utf-8
import os

#読み込むファイルの指定
inp = os.path.dirname(__file__)+"\A-small-practice.in"
oup = os.path.dirname(__file__)+"\A-small-output.txt"

#入力ファイルの読み込み
f = open(inp, 'r')
numofline = int(f.readline()) #行数

#出力ファイルの読み込み
g = open(oup, 'w')

#カットする処理
def cut(cardlist, n, m):
    cutted = cardlist[n-1:n-1 + m] #カットされる部分を抜き出す
    clist = cardlist[:n-1] + cardlist[n-1 + m:] #抜き出された部分以外をくっつける
    return cutted + clist #抜き出した部分を上に乗せる

for i in range(numofline):
    M, C, W = tuple([int(x) for x in f.readline().split()])
    cardlist = list(range(1, M + 1)) #カードの初期順序
    for times in range(C):
        A, B = tuple([int(x) for x in f.readline().split()])
        cardlist = cut(cardlist, A, B)
    g.write("Case #" + str(i + 1) + ": " + str(cardlist[W-1]) + "\n")
    
f.close()
g.close()
print("終了")