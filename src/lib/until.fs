\ lib/until.fs

\ This file is part of Sin Forth.

\ This file adds `until` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261857.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-13: Start.
\
\ 2020-12-26: Update documentation.
