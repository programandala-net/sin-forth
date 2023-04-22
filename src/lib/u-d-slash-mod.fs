\ lib/WORD.fs

\ This file is part of Sin Forth.

\ This file adds `WORD` to the XXX .

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require minus-rot.fs     \ `-rot`
require r-fetch.fs       \ `r@`
require r-from.fs        \ `r>`
require rot.fs           \ `rot`
require to-r.fs          \ `>r`
require u-m-slash-mod.fs \ `um/mod`

get-order get-current

target-definitions

: ud/mod ( ud1 u1 -- urem udquot )
  >r 0 r@ um/mod -rot r> um/mod rot ;

  \ Credit: Code adapted from Solo Forth, previously modified from Z88
  \ CamelForth (Garry Lancaster, 2001).

  \ doc{
  \
  \ ud/mod ( ud1 u2 -- u3 ud4 ) "u-d-slash-mod"
  \
  \ An unsigned mixed magnitude math operation which leaves a
  \ double quotient _ud4_ and remainder _u3_, from a double
  \ dividend _ud1_ and single divisor _u2_.
  \
  \ Origin: fig-Forth's ``m/mod``, Gforth, Z88 CamelForth.
  \
  \ See also: `um/mod`.
  \
  \ }doc

set-current set-order
