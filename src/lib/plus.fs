\ lib/plus.fs

\ This file is part of Sin Forth.

\ This file adds `+` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require pop-hl-de.fs \ `pop-hl-de`
require push-hl.fs   \ `push-hl`

get-order get-current

target-definitions

: + ( n1 n2 -- n3 )
  pop-hl-de \ pop de
            \ pop hl
  d addp,   \ add hl,de
  push-hl ; \ push hl

  \ doc{
  \
  \ + ( n1|u1 n2|u2 -- n3|u3 ) "plus"
  \
  \ Add _n1|u1_ to _n2|u2_, giving the sum _n3|u3_.
  \
  \ // XXX TODO
  \ // See also: `m+`, `d+`, `2+`, `1+`, `-`.
  \ See also: `-`.
  \
  \ }doc

set-current set-order
