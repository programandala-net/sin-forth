\ lib/greater-than.fs

\ This file is part of Sin Forth.

\ This file adds `>` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012262142.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl-de.fs \ `pop-hl-de`
require less-than.fs \ `<`, `hl<de?`

get-order get-current

target-definitions

: > ( n1 n2 -- f )
  pop-hl-de hl<de? ;

  \ doc{
  \
  \ > ( n1 n2 -- f ) "greater-than"
  \
  \ _f_ is true if and only if _n1_ is greater than _n2_.
  \
  \ See also: `<`, `u>`, `0>`, `max`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
