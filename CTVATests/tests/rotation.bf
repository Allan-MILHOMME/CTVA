[a, b, c, d, rotate, loop] {
	
	loop = {
		rotate()
		a()
	}
	
	a = loop
	b = loop
	c = loop
	d = {}
	rotate = [e]{
		e = a
		a = b
		b = c
		c = d
		d = e
	}
	
	loop()
}