\ lib/plus.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-hl-de.fs \ `pop-hl-de`
require push-hl.fs   \ `push-hl`

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
