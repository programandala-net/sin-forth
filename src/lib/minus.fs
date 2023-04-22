\ lib/minus.fs

\ This file is part of Sin Forth.

\ This file adds `-` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require pop-de-hl.fs \ `pop-de-hl`
require push-hl.fs   \ `push-hl`

get-order get-current

target-definitions

: - ( n1 n2 -- n3 )
  pop-de-hl \ pop de
            \ pop hl
  a and,    \ and a
  d sbcp,   \ sbc hl,de
  push-hl ; \ push hl

  \ doc{
  \
  \ - ( n1|u1 n2|u2 -- n3|u3 ) "minus"
  \
  \ Substract _n2|u2_ to _n1|u1_, giving the difference _n3|u3_.
  \
  \ // XXX TODO
  \ // See also: `m+`, `d+`, `2+`, `1+`, `-`.
  \ See also: `+`.
  \
  \ }doc

set-current set-order
