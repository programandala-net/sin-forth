\ lib/r-fetch.fs

\ This file is part of Sin Forth.

\ This file adds `r@` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012181609.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-16: Start.
\
\ 2020-12-18: Document.
