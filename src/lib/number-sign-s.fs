\ lib/number-sign-s.fs
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
