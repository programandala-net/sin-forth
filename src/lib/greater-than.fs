\ lib/greater-than.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

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
