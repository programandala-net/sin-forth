\ lib/r-from.fs

\ This file is part of Sin Forth.

\ This file adds `r>` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012181607.
\ See change log at the end of the file.

\ ==============================================================

require push-de.fs \ `push-de`

get-order get-current

target-definitions

: r> ( R: x -- ) ( -- x )
  h pop,  \ pop hl ; return address
  d pop,  \ pop de ; x
  push-de \ call push_de ; x
  jphl,   \ jp (hl) ; return

  \ doc{
  \
  \ r> ( -- x ) ( R: x -- ) "r-from"
  \
  \ Move _x_ from the return stack to the data stack.
  \
  \ See also: `>r`, `r@`, `2r>`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-16: Start.
\
\ 2020-12-18: Document.
