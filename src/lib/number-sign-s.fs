\ lib/number-sign-s.fs

\ This file is part of Sin Forth.

\ This file adds `#s` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require begin.fs       \ `begin`
require number-sign.fs \ `#`
require or.fs          \ `or`
require two-dup.fs     \ `2dup`
require zero-until.fs  \ `0until`

get-order get-current

target-definitions

: #s ( ud1 -- ud2 )
  begin # 2dup or 0until ;

  \ doc{
  \
  \ #s ( ud1 -- ud2 ) "number-sign-s"
  \
  \ Convert one digit of _ud1_ according to the rule for `#`.
  \ Continue conversion until the quotient is zero. _ud2_ is zero.
  \ Used between `<#` and `#>`.
  \
  \ }doc

set-current set-order
