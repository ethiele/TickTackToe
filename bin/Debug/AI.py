def f():
	for x in range(3):
		for y in range(3):
			if game.GetBox(x, y) == ClearBox:
				game.MakeMove(x, y) 
				return
def g():
	for x in range(1,3):
		for y in range(3):
			if game.GetBox(x, y) == ClearBox:
				game.MakeMove(x, y) 
				return
if player == "X":
	f()
else:
	g()