[index, loop] {
	loop = {
		inc(index, [r]{index = r})
		fib(index, [r]{ diff(r, five, [rr] { rr(loop) } ) })
	}
	loop()
}