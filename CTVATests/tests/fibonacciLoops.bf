[index, loop] {
	loop = {
		inc(index, [r]{index = r})
		fib(index, [r]{ diff(r, four, [rr] { rr(loop) } ) })
	}
	loop()
}