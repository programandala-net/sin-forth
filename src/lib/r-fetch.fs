\ lib/r-fetch.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require push-de.fs \ `push-de`

get-order get-current

target-definitions

: r@ ( -- x ) ( R: x -- x )
  h pop,  \ pop hl ; return address
  d pop,  \ pop de ; x
  d push, \ push de ; x
  push-de \ call push_de ; x
  jphl,   \ jp (hl) ; return

  \ doc{
  \
  \ r@ ( -- x ) ( R: x -- x ) "r-fetch"
  \
  \ Copy _x_ from the return stack to the data stack.
  \
  \ See also: `>r`, `r>`, `rdrop`.
  \
  \ }doc

set-current set-order
