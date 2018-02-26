#! python3
# coding: utf-8
import os

#読み込むファイルの指定
inp = os.path.dirname(__file__)+"\B-small-practice.in"
oup = os.path.dirname(__file__)+"\B-small-output.txt"

#入力ファイルの読み込み
f = open(inp, 'r')
numofline = int(f.readline()) #行数

#出力ファイルの読み込み
g = open(oup, 'w')

#その日最も満足度の高いコーヒーを選択する
def selectcoffee(coffeelist, times):
    remlist =[] #その日残っているコーヒーのリスト番号を入れるリスト
    #消費期限がtimes以上のものだけを抽出する
    for x in range(len(coffeelist)):
        if coffeelist[x][1] >= times:
            remlist.append(x)
    #満足度のみのリストを作成
    slist = []
    for x in range(len(remlist)):
        slist.append(coffeelist[remlist[x]][2])
    #満足度の最大を抽出
    if slist:
        mx = max(slist)
        #最大値の項を検索
        for x in range(len(coffeelist)):
            if coffeelist[x][2] == mx:
                break
        i = x
        print(coffeelist)
        coffeelist[i][0] = coffeelist[i][0] - 1
        if coffeelist[i][0] == 0:
            coffeelist.pop(i) #残数が０になったものはリストから削除
        return mx
    else:
        return 0

for i in range(numofline):
    N, K = tuple([int(x) for x in f.readline().split()])
    coffeelist = list(range(N))
    maxSatisfy = 0
    for kinds in range(N): #リスト内に３つセットでリストを入れ子にする
        coffeelist[kinds] = list([int(x) for x in f.readline().split()])
    for times in range(K, 0, -1): #最終日から逆算していく
        coffeelist.sort(key=lambda x: x[0], reverse=True); coffeelist #残数降順でソートしておく
        maxSatisfy = maxSatisfy + selectcoffee(coffeelist, times)
    g.write("Case #" + str(i + 1) + ": " + str(maxSatisfy) + "\n")
    
f.close()
g.close()
print("終了")