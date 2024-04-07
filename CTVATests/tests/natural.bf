[zero, one, two, three, four, five, inc, dec, add, sub, mul, eq, not, diff, fib] {
	zero = {}
	
	inc = [number, result] {
		result([function]{
			function()
			number(function)
		})
	}
	
	inc(zero, [x]{one = x})
	inc(one, [x]{two = x})
	inc(two, [x]{three = x})
	inc(three, [x]{four = x})
	inc(four, [x]{five = x})
	
	dec = [number, result, current, previous, method] {
		current = {}
		previous = {}
		method = {
			previous = current
			inc(current , [x] { current = x } )
		}
		number(method)
		result(previous)
	}
	
	add = [op1, op2, result] {
		op2({inc(op1, [x]{op1 = x})})
		result(op1)
	}
	
	sub = [op1, op2, result] {
		op2({dec(op1, [x]{op1 = x})})
		result(op1)
	}
	
	mul = [op1, op2, result, inter] {
		inter = zero
		op2({add(op1, inter, [x]{inter = x})})
		result(inter)
	}
	
	eq = [op1, op2, result, r] {
		r = one
		sub(op1, op2, [rr] { rr({r = zero}) })
		sub(op2, op1, [rr] { rr({r = zero}) })
		result(r)
	}
	
	not = [op1, result, r] {
		r = one
		op1({r = zero})
		result(r)
	}
	
	diff = [op1, op2, result] {
		eq(op1, op2, [r]{ not(r, result) })
	}

	fib = [index, result, op1, op2] {
		op1 = one
		op2 = zero
		index([temp]{
			temp = op1
			add(op1, op2, [r]{op1 = r})
			op2 = temp
		})
		result(index)
	}
}