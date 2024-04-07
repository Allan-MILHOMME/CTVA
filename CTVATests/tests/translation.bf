[a, b, c, translate, loop] {
	
	loop = {
		translate()
		a()
	}
	
	a = {}
	b = {}
	c = loop
	translate = {
		a = b
		b = c
	}
	
	loop()
}