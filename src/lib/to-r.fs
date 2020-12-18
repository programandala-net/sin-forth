\ lib/to-r.fs

\ This file is part of Sin Forth.

\ This file adds `>r` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012181608.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-16: Start.
\
\ 2020-12-18: Document.
