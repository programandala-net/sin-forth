\ lib/until.fs

\ This file is part of Sin Forth.

\ This file adds `until` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require zero-branch.fs      \ `0branch`
require backward-resolve.fs \ `<resolve`

get-order get-current

compiler-definitions

: until \ Compilation: ( C: dest -- )
        \ Run-time:    ( f -- )
  0branch compiler{ <resolve } ;

  \ doc{
  \
  \ until
  \   Compilation: ( C: dest -- )
  \   Run-time:    ( f -- )

  \
  \ Compilation: Compile a conditional `0branch` to the backward
  \ reference _dest_, usually left by `begin`.
  \
  \ Run-time: If _f_ is zero, continue execution at the location
  \ specified by _dest_.
  \
  \ See also: `0until`, `-until`, `+until`, `while`, `again`,
  \ `repeat`, `<resolve`.
  \
  \ }doc

set-current set-order
