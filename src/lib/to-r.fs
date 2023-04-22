\ lib/to-r.fs

\ This file is part of Sin Forth.

\ This file adds `>r` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require pop-de.fs \ `pop-de`

get-order get-current

target-definitions

: >r ( x -- ) ( R: -- x )
  pop-de  \ call pop_de ; x
  h pop,  \ pop hl ; return address
  d push, \ push de ; x
  jphl,   \ jp (hl) ; return

  \ doc{
  \
  \ >r ( x -- ) ( R: -- x ) "to-r"
  \
  \ Move _x_ from the data stack to the return stack.
  \
  \ See also: `r>`, `r@`, 2>r`, `dup>r`.
  \
  \ }doc

set-current set-order
